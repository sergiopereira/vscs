# this script will look into each project, find which NuGet packages it
# uses, and install the missing ones.

Dir.glob('VSCheatSheets.*/packages.config') do |f|
	puts '------------------------------'
	puts "Updating packages as listed in #{f} ..."
	puts `nuget i #{f} -o Packages`
end