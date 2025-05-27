namespace GWTAI.Blazor.Client.Models.Common
{
  /// <summary>
  /// Reference structure to all the JS interop classes that we'll use throughout the application.
  /// </summary>
  public static class InteropFunctions
  {
    public static KeyValuePair<string, string[]> ReplaceClass(string id, string classToReplace, string classToUse) =>
        new KeyValuePair<string, string[]>("replaceClass", new[] { id, classToReplace, classToUse });
  }
}
