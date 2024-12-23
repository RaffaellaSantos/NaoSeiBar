﻿using Nao_Sei_Bar_Backend.src.data.enums;
using Swashbuckle.AspNetCore.Annotations;

namespace NSB_API.data.dtos
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        [SwaggerSchema(Description = "Tipo do produto = Cerveja")]
        public Tipo Tipo { get; set; } 
        public double ValorVenda { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
    }
}
