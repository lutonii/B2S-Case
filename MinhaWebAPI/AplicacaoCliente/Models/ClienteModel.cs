using AplicacaoCliente.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AplicacaoCliente.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }


        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> retorno = new List<ClienteModel>();
            string json = WebAPI.RequestGET("listagem", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            return retorno; 
        }

        public ClienteModel Carregar(int? id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestGET("cliente", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;
        }

        public void Inserir()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            string json = string.Empty;

            if (Id == 0)
            {
                WebAPI.RequestPOST("registrarcliente", jsonData);
            }
            else
            {
                WebAPI.RequestPUT("atualizar/"+Id, jsonData);
            }
        }

        public void Excluir(int id)
        {            
            string json = WebAPI.RequestDELETE("excluir", id.ToString());            
        }
    }
}
