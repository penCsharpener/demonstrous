# `install .` install the new template from current directory
dotnet new install . --force

# use `dotnet new --list` to check whether your template was installed

# using the template: dotnet new mudblazortemplate -o "MyWorkerService" -F net8.0 -A "true"