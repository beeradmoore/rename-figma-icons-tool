
void ShowUsage()
{
    Console.WriteLine("Usage: ");
    Console.WriteLine(" rename-figma-icons /Path/To/Downloaded/Files/From/FigmaFolder");
    //Console.WriteLine(" rename-figma-icons /Path/To/Downloaded/Files/From/Package.zip");
}

if (args.Length == 0 || args.Length > 1)
{
    ShowUsage();
    return 1;
}

var inputDirectory = args[0];
if (Directory.Exists(inputDirectory) == false)
{
    Console.WriteLine($"Error: \"{inputDirectory}\" does not exist.");
    return 1;
}

var mdpiPath = Path.Combine(inputDirectory, "drawable-mdpi");
var hdpiPath = Path.Combine(inputDirectory, "drawable-hdpi");
var xhdpiPath = Path.Combine(inputDirectory, "drawable-xhdpi");
var xxhdpiPath = Path.Combine(inputDirectory, "drawable-xxhdpi");
var xxxhdpiPath = Path.Combine(inputDirectory, "drawable-xxxhdpi");
Directory.CreateDirectory(mdpiPath);
Directory.CreateDirectory(hdpiPath);
Directory.CreateDirectory(xhdpiPath);
Directory.CreateDirectory(xxhdpiPath);
Directory.CreateDirectory(xxxhdpiPath);


try
{
    foreach (var filename in Directory.GetFiles(inputDirectory))
    {
        var rawFilename = Path.GetFileNameWithoutExtension(filename)
                .Replace("-mdpi", String.Empty)
                .Replace("-hdpi", String.Empty)
                .Replace("-xhdpi", String.Empty)
                .Replace("-xxhdpi", String.Empty)
                .Replace("-xxxhdpi", String.Empty)
                .Replace("@2x", String.Empty)
                .Replace("@3x", String.Empty)
                .Replace("-", "_")
                .ToLower();


        if (filename.EndsWith("-mdpi.png"))
        {
            Console.WriteLine($"Moving {filename} to  {Path.Combine(mdpiPath, $"{rawFilename}.png")}");
            File.Move(filename, Path.Combine(mdpiPath, $"{rawFilename}.png"));
        }
        else if (filename.EndsWith("-hdpi.png"))
        {
            Console.WriteLine($"Moving {filename} to  {Path.Combine(hdpiPath, $"{rawFilename}.png")}");
            File.Move(filename, Path.Combine(hdpiPath, $"{rawFilename}.png"));
        }
        else if (filename.EndsWith("-xhdpi.png"))
        {
            Console.WriteLine($"Moving {filename} to  {Path.Combine(xhdpiPath, $"{rawFilename}.png")}");
            File.Move(filename, Path.Combine(xhdpiPath, $"{rawFilename}.png"));
        }
        else if (filename.EndsWith("-xxhdpi.png"))
        {
            Console.WriteLine($"Moving {filename} to  {Path.Combine(xxhdpiPath, $"{rawFilename}.png")}");
            File.Move(filename, Path.Combine(xxhdpiPath, $"{rawFilename}.png"));
        }
        else if (filename.EndsWith("-xxxhdpi.png"))
        {
            Console.WriteLine($"Moving {filename} to  {Path.Combine(xxxhdpiPath, $"{rawFilename}.png")}");
            File.Move(filename, Path.Combine(xxxhdpiPath, $"{rawFilename}.png"));
        }
    }
}
catch (Exception err)
{
    Console.WriteLine($"Exception: {err.Message}");
    return 1;
}

return 0;

/*

// This was used when we were extracting from zip, but that functionality is disabled.
bool ExtractFile(ZipArchiveEntry entry, string outputFile)
{
    Console.WriteLine($" -> Extracting \"{entry.FullName}\" to \"{outputFile}\"");
    if (File.Exists(outputFile))
    {
        Console.WriteLine($"Error: {outputFile} already exists, skipping.");
        return false;
    }

    try
    {
        entry.ExtractToFile(outputFile);
        return true;
    }
    catch (Exception err)
    {
        Console.WriteLine($"Exception: {err.Message}");
        return false;
    }
}

try
{
    using (var archive = ZipFile.OpenRead(inputFile))
    {
        var filesFound = archive.Entries.Count;
        var filesExtracted = 0;
        foreach (var entry in archive.Entries)
        {
            if (String.IsNullOrEmpty(entry.Name))
            {
                continue;
            }

            if (entry.Name.EndsWith(".png") == false)
            {
                Console.WriteLine($"Warning: Expected all png files, found \"{entry.Name}\"");
                continue;
            }

            var rawEntryName = Path.GetFileNameWithoutExtension(entry.Name)
                .Replace("-mdpi", String.Empty)
                .Replace("-hdpi", String.Empty)
                .Replace("-xhdpi", String.Empty)
                .Replace("-xxhdpi", String.Empty)
                .Replace("-xxxhdpi", String.Empty)
                .Replace("@2x", String.Empty)
                .Replace("@3x", String.Empty)
                .Replace("-", "_")
                .ToLower();

            if (entry.Name.EndsWith("-mdpi.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(mdpiPath, $"{rawEntryName}.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else if (entry.Name.EndsWith("-hdpi.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(hdpiPath, $"{rawEntryName}.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else if (entry.Name.EndsWith("-xhdpi.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(xhdpiPath, $"{rawEntryName}.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else if (entry.Name.EndsWith("-xxhdpi.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(xxhdpiPath, $"{rawEntryName}.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else if (entry.Name.EndsWith("-xxxhdpi.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(xxxhdpiPath, $"{rawEntryName}.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else if (entry.Name.EndsWith("@3x.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(outputDirectory, $"{rawEntryName}@3x.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else if (entry.Name.EndsWith("@2x.png"))
            {
                var didExtract = ExtractFile(entry, Path.Combine(outputDirectory, $"{rawEntryName}@2x.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
            else
            {
                // We can only assume this is iOS @1x image
                var didExtract = ExtractFile(entry, Path.Combine(outputDirectory, $"{rawEntryName}.png"));
                if (didExtract)
                {
                    ++filesExtracted;
                }
            }
        }
        Console.WriteLine($"Extracted {filesExtracted} files.");
    }

}
catch (Exception err)
{
    Console.WriteLine($"Exception: {err.Message}");
}
*/