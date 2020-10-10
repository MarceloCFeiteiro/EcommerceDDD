﻿using Entities.Notifiations;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_PRODUTO")]
    public class Produto : Notifies
    {
        [Column("PRD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PRD_NOME")]
        [MaxLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("PRD_DESCRICAO")]
        [MaxLength(150)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("PRD_OBSERVACAO")]
        [MaxLength(2000)]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Column("PRD_VALOR")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("PRD_QTD_ESTOQUE")]
        [Display(Name = "Quantidade de Estoque")]
        public int QtdEstoque { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; } 

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column("PRD_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Column("PRD_DATA_ALTERACAO")]
        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [Column("PRD_DATA_CADASTRO")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }        

        [Column("PRD_URL")]
        public string Url { get; set; }

        [NotMapped]
        public DateTime? DataCompra { get; set; }

        [NotMapped]
        public int IdProdutoCarrinho { get; set; }

        [NotMapped]
        public int QtdCompra { get; set; }

        [NotMapped]
        public IFormFile Imagem { get; set; }
    }
}