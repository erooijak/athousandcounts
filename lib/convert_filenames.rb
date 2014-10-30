puts "Renaming files...\n"

folder_path = "[Path to files]"
Dir.glob(folder_path + "*").each do |f|
   name = File.basename(f).gsub(/.*athousandcounts/, '')
   File.rename(f, folder_path + name)
   puts "Created file #{name}..."
end
puts "\nRenaming complete."
