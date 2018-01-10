module.exports = function(grunt) {
  // Do grunt-related things in here
  
  grunt.initConfig({
	exec: {
			list_files: {
				cmd: '"C:\\Program Files (x86)\\Microsoft SQL Server\\140\\DAC\\bin\\SqlPackage.exe"'
			},
			echo_stuff: {
				cmd: function() {return 'echo hello world';}
			}
	},
	watch: {
		dostuff: {
			files: ['EM.DB/*.sql'],
			tasks: ['exec:echo_stuff']
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