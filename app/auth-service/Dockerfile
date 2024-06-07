FROM rust:latest as builder

WORKDIR /usr/src/app

# Copy the entire source code
COPY . .

# Build the application
RUN cargo build --release

# Runtime Stage
FROM registry.access.redhat.com/ubi9-minimal:9.2

WORKDIR /usr/src/app

# Copy only the built artifacts and configuration files
COPY --from=builder /usr/src/app/target/release/auth-service .

# Expose the port your application will run on
EXPOSE 3000

# Run your application
CMD ["./auth-service"]