using System.Runtime.Serialization;

namespace RestWithASP_NET.Model.Base
{
    //Contrato entre atributos
    // e a estrutura da tabela
    //[DataContract]
    public class BaseEntity
    {
        public long? id {get;set;}
    }
}