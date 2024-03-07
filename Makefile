compile-all:
	@echo. 
	@echo --- auth-service ---
	@echo. 
	cargo check --manifest-path .\app\auth-service\Cargo.toml 

	@echo. 
	@echo --- blog-service ---
	@echo. 
	dotnet build .\app\blog-service

	@echo. 
	@echo --- terraform ---	
	@echo. 
	terraform fmt -check .\infra\ 

test-all:
	echo "TODO";