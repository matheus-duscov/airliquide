using System;
using System.ComponentModel.DataAnnotations;

namespace Airliquide.Contracts.Contracts
{
    public class ClienteDto
    {
        /// <summary>
        /// Id do registro.
        /// </summary>
        /// <example>
        /// "6EBAE6E8-C518-49C9-A9DE-CABDB53D6792"
        /// </example>
        public Guid Id { get; set; }

        /// <summary>
        /// Obrigatório. Nome do cliente.
        /// </summary>
        /// <example>
        /// Teutônio Mascarenhas
        /// </example>
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        /// <summary>
        /// Obrigatório. Idade do cliente.
        /// </summary>
        /// <example>
        /// 33
        /// </example>
        [Required]
        [Range(0, 150)]
        public int Idade { get; set; }
    }
}
