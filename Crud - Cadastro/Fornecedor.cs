using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud___Cadastro
{
    internal class Fornecedor
    {
        private int id;
        private string razao_social;
        private string nome_fantasia;
        private string cnpj;  
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public string GetRazaoSocial()
        {
            return razao_social;
        }
        public void SetRazaoSocial(string razao_social)
        {
            this.razao_social = razao_social;
        }
        public string GetNomeFantasia()
        {
            return nome_fantasia;
        }
        public void SetNomeFantasia(string fantasia)
        {
            this.nome_fantasia = fantasia;
        }
        public string GetCNPJ()
        {
            return cnpj;
        }
        public void SetCNPJ(string cnpj)
        {
            this.cnpj = cnpj;
        }
    }
}
