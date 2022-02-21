using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Catalog.Client.Shared
{
    public partial class AppBar
    {
        [Parameter]
        public EventCallback OnSidebarToggled { get; set; }
       
        private async Task ToggleSidebar()
        {
           await OnSidebarToggled.InvokeAsync();
        
        }

        [Parameter]
        public EventCallback OnThemeToggled { get; set; }
        private bool themeMode = true;
        private async Task ToggleTheme()
        {
            themeMode = !themeMode;
            await OnThemeToggled.InvokeAsync();

        }
        private string GetThemeIcon() => themeMode ? Icons.Material.Filled.Brightness5 : Icons.Material.Filled.Brightness4;
    }
}
