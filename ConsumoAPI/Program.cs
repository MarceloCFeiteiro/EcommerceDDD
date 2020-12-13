using Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace ConsumoAPI
{
    internal class Program
    {
        public static string Token { get; set; }
        public static List<Produto> ListaDeProdutos { get; set; }

        private static void Main(string[] args)
        {
            Console.WriteLine("Teste API Rodando");
            Thread.Sleep(10000);

            GetProduto();

            foreach (var produto in ListaDeProdutos)
            {
                Console.WriteLine("Código : " + produto.Id);

                Console.WriteLine("Nome : " + produto.Nome);
            }

            //ListarProdutos();

            Console.ReadLine();
        }

        public static void GetToken()
        {
            string urlApiGeraToken = "https://localhost:5001/api/CreateToken";

            using (var cliente = new HttpClient())
            {
                string login = "mfeiteiro@yahoo.com.br";
                string senha = "Aioli@1002";

                var dados = new
                {
                    Email = login,
                    Password = senha
                };

                string JsonObjeto = JsonConvert.SerializeObject(dados);

                var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

                var resultado = cliente.PostAsync(urlApiGeraToken, content);

                resultado.Wait();

                if (resultado.Result.IsSuccessStatusCode)
                {
                    var tokenJson = resultado.Result.Content.ReadAsStringAsync();
                    Token = JsonConvert.DeserializeObject(tokenJson.Result).ToString();
                }
            }
        }

        public static void GetProduto()
        {
            GetToken();

            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var cliente = new HttpClient())
                {
                    string urlApiGeraToken = "https://localhost:5001/api/ListaProdutos";

                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = cliente.GetStringAsync(urlApiGeraToken);
                    response.Wait();
                    var listaRetorno = JsonConvert.DeserializeObject<Produto[]>(response.Result).ToList();
                    ListaDeProdutos = listaRetorno;
                }
            }
        }

        #region BONUS Para os inscritos do canal DEV NET Core..

        private static string GerarToken(string login, string senha)
        {
            string urlApiGeraToken = "https://localhost:5001/api/CreateToken";

            var dados = new
            {
                Email = login,
                Password = senha
            };

            string retornoStringAPI = ChamadaApis(HttpMethod.Post, urlApiGeraToken, dados, false);
            var tokenRetorno = JsonConvert.DeserializeObject<string>(retornoStringAPI);
            return tokenRetorno;
        }

        private static string ChamadaApis(HttpMethod tipoHttpMethod, string api, object objeto, bool usarLogin = false)
        {
            string retorno = string.Empty;
            string login = "mfeiteiro@yahoo.com.br";
            string senha = "Aioli@1002";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(tipoHttpMethod, api))
                {
                    if (usarLogin)
                    {
                        var token = GerarToken(login, senha);
                        if (token != null)
                        {
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        }
                    }
                    client.Timeout = new TimeSpan(0, 0, 100);

                    if (objeto != null)
                    {
                        string dadosSerializados = JsonConvert.SerializeObject(objeto);
                        request.Content = new StringContent(dadosSerializados, Encoding.UTF8, "application/json");
                    }

                    var response = client.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        retorno = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            return retorno;
        }

        private static List<Produto> ListarProdutos()
        {
            string urlApiGeraToken = "https://localhost:5001/api/ListaProdutos";

            string retornoStringAPI = ChamadaApis(HttpMethod.Get, urlApiGeraToken, null, true);
            var objRetorno = JsonConvert.DeserializeObject<List<Produto>>(retornoStringAPI);

            return objRetorno;
        }

        #endregion BONUS Para os inscritos do canal DEV NET Core..
    }
}