using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CatFacts.Services;

namespace CatFacts.Pages
{
    public class SavedFactsModel : PageModel
    {
        private readonly FileViewerService _fileViewerService;
        public List<string> SavedFacts { get; set; }
        public SavedFactsModel(FileViewerService fileViewerService)
        {
            _fileViewerService = fileViewerService;
        }
        public async Task OnGetAsync()
        {
            SavedFacts = await _fileViewerService.GetSavedCatFactsAsync();
        }
    }
}
