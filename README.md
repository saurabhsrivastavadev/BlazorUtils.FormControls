# BlazorUtils.FormControls

This project provides razor components which can be used in a Form.

### Installation
> Add reference to this BlazorUtils.FormControls project in your Blazor project<br>
> The path will be specific to where you pull this repo on your system.
```
<ProjectReference Include="..\..\BlazorUtils\BlazorUtils.FormControls\BlazorUtils.FormControls.csproj" />
```

> There is no need to add any initialization to Program.cs or any script to index.html

### Usage
> Add below directives to get shorthand access to the FormControls:
```
@using BlazorUtils.FormControls
```
> Then use the required component, like the Typeahead component below:
```
    <div class="card-body">
        <Typeahead Placeholder="Type any part of a timezone name.."
                   AllowOnlySuggestedValues="true"
                   Suggestions="@_timezoneList"
                   SubmitButtonText="Add the selected timezone/s"
                   SubmitCallback="AddTimezoneCards"></Typeahead>
    </div>
```

### Demo Project
Here's a project which uses BlazorUtils.FormControls library:<br>
https://github.com/sobu86/TimeUtilities

You can take a look at this commit specifically which utilizes the Typeahead component:<br>
https://github.com/sobu86/TimeUtilities/commit/0ce056da990bcb56976fa77e5a673392d9edeb35
