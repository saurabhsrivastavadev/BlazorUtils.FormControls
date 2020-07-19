using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BlazorUtils.FormControls
{
    public partial class Typeahead
    {
        [Inject]
        private ILogger<Typeahead> Logger { get; set; }

        [Parameter]
        public ISet<string> Suggestions { get; set; }

        [Parameter]
        public bool AllowOnlySuggestedValues { get; set; } = true;

        [Parameter]
        public string Placeholder { get; set; } = string.Empty;

        [Parameter]
        public string SubmitButtonText { get; set; } = "Submit the selected values";

        [Parameter]
        public EventCallback<ISet<string>> SubmitCallback { get; set; }

        [Parameter]
        public bool ClearSelectionOnSubmit { get; set; } = true;

        private string CurrentValue { get; set; } = string.Empty;

        private string _lastValue = string.Empty;
        private ISet<string> _matchingSuggestions = new HashSet<string>();
        private Timer _debounceTimer = new Timer(400);
        private ISet<string> _selectedValues = new HashSet<string>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _debounceTimer.AutoReset = false;
            _debounceTimer.Elapsed += DebounceTimerCb;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Suggestions.Count == 0 && AllowOnlySuggestedValues)
            {
                Logger.LogError("No suggestions in the typeahead component.");
            }
        }

        private void HandleKeyUp(KeyboardEventArgs args)
        {
            _debounceTimer.Stop();
            _debounceTimer.Start();

            if (args.Key == "Enter" && CurrentValue.Length > 0 && !AllowOnlySuggestedValues)
            {
                _selectedValues.Add(CurrentValue);
            }
        }

        private void DebounceTimerCb(object sender, ElapsedEventArgs args)
        {
            if (CurrentValue.Length > 1 && CurrentValue != _lastValue)
            {
                _matchingSuggestions.Clear();
                _matchingSuggestions.UnionWith(Suggestions.Where(
                    s => s.Contains(CurrentValue, StringComparison.OrdinalIgnoreCase)));
                StateHasChanged();
            }
            else if (CurrentValue != _lastValue)
            {
                _matchingSuggestions.Clear();
                StateHasChanged();
            }

            _lastValue = CurrentValue;
        }

        private void SubmitSelectedValues()
        {
            SubmitCallback.InvokeAsync(_selectedValues);

            if (ClearSelectionOnSubmit)
            {
                _selectedValues.Clear();
                CurrentValue = string.Empty;
            }
        }
    }
}
