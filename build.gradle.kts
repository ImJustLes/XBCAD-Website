plugins {
	java
	id("org.springframework.boot") version "3.3.3"
	id("io.spring.dependency-management") version "1.1.6"
}

group = "co.za"
version = "0.0.1-SNAPSHOT"

java {
	toolchain {
		languageVersion = JavaLanguageVersion.of(21)
	}


}

repositories {
	mavenCentral()
}

dependencies {
	compileOnly("org.springframework.boot:spring-boot-devtools")

	//Google OAuth Client
	implementation("com.google.api-client:google-api-client:2.1.2")
	implementation("com.google.oauth-client:google-oauth-client:1.34.1")

	//Google Calendar API
	implementation("com.google.apis:google-api-services-calendar:v3-rev20220715-2.0.0")

	//Save Guava version
	implementation("com.google.guava:guava:32.0.0-jre")

	//Firebase dependency Import
	implementation("com.google.firebase:firebase-admin:9.1.1")

	//MongoDB dependency Import
	implementation("org.springframework.boot:spring-boot-starter-data-mongodb")

	//Thyme Leaf dependency import
	implementation("org.springframework.boot:spring-boot-starter-thymeleaf")

	//Website
	implementation("org.springframework.boot:spring-boot-starter-web")

	implementation("org.springframework:spring-context")
	testImplementation("org.springframework.boot:spring-boot-starter-test")
	testRuntimeOnly("org.junit.platform:junit-platform-launcher")
}

tasks.withType<Test> {
	useJUnitPlatform()
}


