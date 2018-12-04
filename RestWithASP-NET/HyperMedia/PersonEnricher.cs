using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithASP_NET.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithASP_NET.HyperMedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/persons/V1";
            var url = new {Controller = path, id = content.id};
            //GET
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("DefaultApi",url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            //POST
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("DefaultApi",url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            //PUT
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("DefaultApi",url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            //DELETE
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DefaultApi",url),
                Rel = RelationType.self,
                Type = "int",
            });

            return null;
        }
    }
}