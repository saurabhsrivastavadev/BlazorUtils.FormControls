# Typeahead Razor Component

This component provides a typeahead control which is an input text box with pre-configured suggestions.

### Usage
> Here is how a Typeahead component is used in another component or page:
```
    <div class="card-body">
        <Typeahead Placeholder="Text that shows up in the text box when empty"
                   AllowOnlySuggestedValues="true"
                   Suggestions="@SetOfSuggestions"
                   SubmitButtonText="Text that shows up on the Submit Button"
                   SubmitCallback="OnSubmit"></Typeahead>
    </div>
```

### Parameters

#### Suggestions
```
Type: ISet<string>
Default: null

Set of string suggestions that show up when user types in the search box.
```
#### AllowOnlySuggestedValues
```
Type: bool
Default: true

Allow to submit value only from the set of suggestions provided if true.
Allow any value typed in the search box if false.
```
#### Placeholder
```
Type: string
Default: string.Empty

Specifies the text that shows up in the search box.
```
#### SubmitButtonText
```
Type: string
Default: "Submit the selected values"

Specifies the text that shows up on the Submit Button.
```
#### SubmitCallback
```
Type: EventCallback<ISet<string>>
Default: null

Callback triggered when user clicks the submit button.
Set of selected values is passed in as argument.
```
#### ClearSelectionOnSubmit
```
Type: bool
Default: true

Should the values selected by user be cleared when submit button is clicked.
```

### Live Demo 
You can take a look at the Typeahead component in action below:<br>
https://timeutilities.web.app/ <br>
Look at the card titled "Add a new Timezone Card"

### Code Usage Demo
You can take a look at this commit specifically which utilizes the Typeahead component:<br>
https://github.com/sobu86/TimeUtilities/commit/0ce056da990bcb56976fa77e5a673392d9edeb35

### Note
```
I apologize in advance for out of date documentation, since it's bound to happen sooner or later.
The best documentation is always the source, so please dive in.
``` 