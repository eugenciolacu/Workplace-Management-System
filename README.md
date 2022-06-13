# Workplace-Management-System

# migration instructions for Package Manager Console
add-migration -Context "AuthDbContext" InitialAuth
add-migration -Context "CoreDbContext" InitialCore
update-database -Context "AuthDbContext"
update-database -Context "CoreDbContext"
