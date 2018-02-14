reflective_load: reflective_load.cs IronPython.2.7.7/lib/Net45/IronPython.dll DynamicLanguageRuntime.1.2.0/lib/net45/Microsoft.Scripting.dll
	mcs -resource:DynamicLanguageRuntime.1.2.0/lib/net45/Microsoft.Scripting.dll,ScriptingDll -resource:IronPython.2.7.7/lib/Net45/IronPython.dll,IronPythonDll reflective_load.cs

clean:
	rm *.exe
