﻿using CaelumEstoque.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public String Nome { get; set; }

        [Range(0.01 , 10000.00)]    
        //[MinValueAttribute(0)]
        public float Preco { get; set; }   

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }
         
        [Required, StringLength(50)]
        public String Descricao { get; set; }

        [Range(1 , 1000)]
        public int Quantidade { get; set; }
    }
}