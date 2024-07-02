using ScreenSound.Modelos;
using Npgsql;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    public static async ValueTask<IEnumerable<Artista>> ListarMusicos()
    {
        List<Artista> lista = new List<Artista>();
        await using (var cmd = new NpgsqlCommand("SELECT * FROM artistas", Connection.conn)) 
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                    
                string nomeArtista = reader.GetString(1);
                string bioArtista = reader.GetString(2);
                int idArtista = reader.GetInt16(0);
                Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
                    
                lista.Add(artista);
            }
            //Get string do coluna referente
        }

        return lista;
    }

    public static async Task IncluirArtista(Artista artista)
    // Task é o retorno recomendade de funções async que não retornam valor
    {
        string sql = "INSERT INTO artistas (nome, bio, fotoperfil) VALUES (@Nome, @Bio, @FotoPerfil)";
    
        await using var cmd = new NpgsqlCommand(sql, Connection.conn) ;
        
            // Construção do comando
            cmd.Parameters.AddWithValue("Nome", artista.Nome);
            cmd.Parameters.AddWithValue("Bio", artista.Bio);
            cmd.Parameters.AddWithValue("FotoPerfil", artista.FotoPerfil);
        
            await cmd.ExecuteNonQueryAsync();
        
    }
    
}