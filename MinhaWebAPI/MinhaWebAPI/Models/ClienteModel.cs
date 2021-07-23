using MinhaWebAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }


        public void RegistrarCliente()
        {
            DAL objDAL = new DAL();

            string sql = "insert into cliente(nome,data_cadastro) " +
                         $"values('{Nome}','{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}')";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void AtualizarCliente()
        {
            DAL objDAL = new DAL();

            string sql = "update cliente set " +
                         $"nome ='{Nome}'," +
                         $"data_cadastro='{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}' where id={Id}"; 

            objDAL.ExecutarComandoSQL(sql);
        }   
                
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"delete from cliente where id = {id}";
            objDAL.ExecutarComandoSQL(sql);
        }

        public List<ClienteModel> Listagem()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = "select * from cliente order by nome asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClienteModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome = dados.Rows[i]["Nome"].ToString(),
                    Data_Cadastro = DateTime.Parse(dados.Rows[i]["data_cadastro"].ToString()).ToString("dd/MM/yyyy")
                };

                lista.Add(item);
            }
            return lista;
        }

        public ClienteModel RetornarCliente(int id)
        {            
            ClienteModel item;
            DAL objDAL = new DAL();

            string sql = $"select * from cliente where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);
       
            item = new ClienteModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome = dados.Rows[0]["Nome"].ToString(),
                Data_Cadastro = DateTime.Parse(dados.Rows[0]["data_cadastro"].ToString()).ToString("dd/MM/yyyy")
            };

            return item;
        }
    }
}
