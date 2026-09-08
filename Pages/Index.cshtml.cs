using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CatFacts.Services;

namespace CatFacts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatFactsService _catFactService;
        public CatFactsDto? LatestFact { get; set; }
        public string? Message { get; private set; }
        public string? ErrorMessage { get; private set; }

        public IndexModel(ICatFactsService catFactsService)
        {
            _catFactService = catFactsService;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            LatestFact = await _catFactService.GetRandomCatFactAsync();
            if (LatestFact == null)
            {
                ErrorMessage = "Failed to retrieve a cat fact. Please try again.";
            }
            else
            {
                Message = $"Fact added: {LatestFact.Fact} (Length: {LatestFact.Length})";

            }
            return Page();
        }
    }
}
