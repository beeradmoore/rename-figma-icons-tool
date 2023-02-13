# Rename Figma Icons Tool
## Install
`dotnet tool install --global rename-figma-icons`

## Usage
Downloading icons from Figma will have a suffix applied which is not useful in some circumstances, such as when working with Android assets. For example you may have a list of files that looks like this.
```
my_icon.png
my_icon@2x.png
my_icon@3x.png
my_icon-mdpi.png
my_icon-hdpi.png
my_icon-xhdpi.png
my_icon-xxhdpi.png
my_icon-xxxhdpi.png
```
Ideally these icons are separated for use in iOS and Android separately. If you navigate to this directory and run

```
rename-figma-icons .
``` 
you now have a directory structure like this
```
my_icon.png
my_icon@2x.png
my_icon@3x.png
drawable-mdpi/my_icon.png
drawable-hdpi/my_icon.png
drawable-xhdpi/my_icon.png
drawable-xxhdpi/my_icon.png
drawable-xxxhdpi/my_icon.png
```
ready for import into your IDE for both iOS and Android projects.


## Future work
- Create entry for .xcassets and relevant .csproj changes.