namespace ReflectiveLoadingTest
{
  using System;
  using System.Reflection;
  using System.Resources;

  class Program
  {
    static void Main(string[] args)
    {
      using(System.IO.Stream IronPythonDllStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("IronPythonDll"))
      using(System.IO.Stream ScriptingDllStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ScriptingDll"))
      {
        byte[] IronPythonDllBytes = new byte[IronPythonDllStream.Length];
        IronPythonDllStream.Read(IronPythonDllBytes, 0, IronPythonDllBytes.Length);

        byte[] ScriptingDllBytes = new byte[ScriptingDllStream.Length];
        ScriptingDllStream.Read(ScriptingDllBytes, 0, ScriptingDllBytes.Length);

        Assembly.Load(ScriptingDllBytes);
        var IronPythonAssembly = Assembly.Load(IronPythonDllBytes);
        MethodInfo entryPoint = IronPythonAssembly.EntryPoint;
        Console.WriteLine("---- Entrypoint ----");
        Console.WriteLine(entryPoint);
        Console.WriteLine("----");
        Console.WriteLine(IronPythonAssembly.CodeBase);

        foreach(Type type in IronPythonAssembly.GetExportedTypes())
        {
          Console.WriteLine(type.FullName);
            // dynamic c = Activator.CreateInstance(type);
            // c.Output(@"Hello");
        }
      }

      Console.ReadLine();
    }
  }
}
