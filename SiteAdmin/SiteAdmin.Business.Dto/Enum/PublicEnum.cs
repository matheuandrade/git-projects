using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SiteAdmin.Business.Dto
{
    public class PublicEnum
    {
    }

    public enum VisibilityEnum
    {
        [Value("I")]
        Interno,

        [Value("E")]
        Externo,
    }

    public enum ActiveEnum
    {
        [Value(true)]
        Ativo,
        [Value(false)]
        Inativo
    }

    public enum Operation
    {
        [Value("C")]
        Create,
        [Value("U")]
        Update,
        [Value("D")]
        Detail
    }

    public enum LanguageEnum
    {
        [DescriptionAttribute("Português")]
        [Value("pt")]
        Portugues,

        [DescriptionAttribute("Inglês")]
        [Value("en-US")]
        Ingles
    }
}
