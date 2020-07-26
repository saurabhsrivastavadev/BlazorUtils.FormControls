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

### Components
> Individual components are each in their own folder, with their corresponding README file.<br>
> Please browse to the component folder which you are interested in.

### Demo Project
Here's a project which uses BlazorUtils.FormControls library:<br>
https://github.com/sobu86/TimeUtilities <br>
It might not showcase all the available components, for which there is plan to have a demo site. 

