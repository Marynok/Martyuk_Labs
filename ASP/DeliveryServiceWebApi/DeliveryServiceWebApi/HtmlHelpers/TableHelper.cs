using DeliveryServiceWebApi.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using FormMethod = Microsoft.AspNetCore.Mvc.Rendering.FormMethod;
using TagBuilder = Microsoft.AspNetCore.Mvc.Rendering.TagBuilder;

namespace DeliveryServiceWebApi.HtmlHelpers
{
    public static class TableHelper
    {
        public static HtmlString CreateTableWithFoods(this IHtmlHelper html, IEnumerable<FoodModel> foods)
        {
            string result = default;
            foreach (var food in foods)
            {
                result = $"{result}<tr><td>{food.Name}</td>" +
                    $"<td>{food.Manufacturer?.Name}</td>" +
                    $"<td>{food.Price}</td>" +
                    $"<td>{food.Weight}</td>" +
                    $"<td>{food.Type?.Name}</td>";

                var htmlActions = AddRUD(html,"FoodMvc", food.Id);
                result = $"{result} {htmlActions}</tr>";
            };
            return new HtmlString(result);
        }
       
        private static HtmlString AddRUD(this IHtmlHelper html, string controller, int id)
        {
            TagBuilder tdEdit = new TagBuilder("td");
            tdEdit.InnerHtml.AppendHtml(html.ActionLink("Edit", "Edit", $"{controller}", new { id = id }));

            TagBuilder tdDetails = new TagBuilder("td");
            tdDetails.InnerHtml.AppendHtml(html.ActionLink("Details", "Details", $"{controller}", new { id = id }));

            TagBuilder tdDelete = new TagBuilder("td");
            tdDelete.InnerHtml.AppendHtml(html.ActionLink("Delete", "DeleteView", $"{controller}", new { id = id }));

            var writer = new System.IO.StringWriter();

            tdEdit.WriteTo(writer, HtmlEncoder.Default);
            tdDetails.WriteTo(writer, HtmlEncoder.Default);
            tdDelete.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());

        }
    }
}
