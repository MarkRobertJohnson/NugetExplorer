using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

using NuGet;

namespace NugetExplorer
{
	[Cmdlet(VerbsCommon.Get,"NugetPackages")]
	
    public class Get_NugetPackages : PSCmdlet
    {
		[Parameter(Position = 0, Mandatory = false, HelpMessage = "The URI of the Nuget package repository")]
		public string Source { get; set; }

		protected  override  void BeginProcessing()
		{
			var repo = PackageRepositoryFactory.Default.CreateRepository(Source);
			
			WriteObject(repo.GetPackages());
		}
    }
}
