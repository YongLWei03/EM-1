module.exports = function(grunt) {
	// Do grunt-related things in here
	
	grunt.initConfig({
		exec: {
			db_build: {
				cmd: '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\MSBuild\\15.0\\Bin\\MSBuild.exe" .\\EM.DB\\EM.DB.sqlproj /t:Rebuild'			},
				db_publish: {
					cmd: '"C:\\Program Files (x86)\\Microsoft SQL Server\\140\\DAC\\bin\\SqlPackage.exe" /Action:Publish /Profile:.\\EM.DB\\EM.DB.publish.xml /SourceFile:.\\EM.DB\\bin\\Debug\\EM.DB.dacpac'
				},
				
				edmx_generate: {
					cmd:'"C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\EdmGen.exe" /mode:fullgeneration /c:"metadata=res://*/EntityDataModel.csdl|res://*/EntityDataModel.ssdl|res://*/EntityDataModel.msl;provider=System.Data.SqlClient;provider connection string="data source=hydral\\sqlexpress01;initial catalog=EM.DB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"" /project:EM.DBModel /entitycontainer:Entities /namespace:EM.DBModel /language:CSharp'
				},
				
				copy_plugins_debug: {
					cmd:'copy .\\EM.Plugin.Sample\\bin\\Debug\\EM.Plugin.Sample.* .\\EM.Cmd\\bin\\Debug\\',
					exitCodes: [0,1]
				},
				copy_plugins_release: {
					cmd:'copy .\\EM.Plugin.Sample\\bin\\Release\\EM.Plugin.Sample.* .\\EM.Cmd\\bin\\Release\\',
					exitCodes: [0,1]				
				},
				
				test_em_common: {
					cmd: '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\Common7\\IDE\\mstest.exe" /testcontainer:.\\EM.Common.Tests\\bin\\Debug\\EM.Common.Tests.dll'
				},
				
				echo_stuff: {
					cmd: function() {return 'echo hello world';}
				}
			},
			watch: {
				configFiles: {
					files: [ 'Gruntfile.js' ],
					options: {
						reload: true
					}
				},
				db_files: {
					files: ['EM.DB/*.sql'],
					tasks: ['exec:db_build','exec:db_publish'],
					options: {
						interrupt: true,
						debounceDelay: 10000,
					},
				},
				plugin_files: {
					files: ['EM.Plugin.Sample/bin/Debug/*','EM.Plugin.Sample/bin/Release/*'],
					tasks: ['exec:copy_plugins_debug','exec:copy_plugins_release'],
					options: {
						event: ['added'],
					},
				},
				test_files_em_common: {
					files: ['EM.Common.Tests/bin/Debug/EM.Common.Tests.dll',],
					tasks: ['exec:test_em_common'],
					options: {
						event: ['added'],
					},				
				}
			}
		}
	);
	
	// A very basic default task.
	grunt.registerTask('default', 'Log some stuff.', function() {
		grunt.log.write('Logging some stuff...').ok();
	});
	
	grunt.loadNpmTasks('grunt-exec');
	grunt.loadNpmTasks('grunt-contrib-watch');
};