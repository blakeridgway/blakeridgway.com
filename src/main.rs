#[macro_use]
extern crate rocket;

use rocket::{Build, Rocket};

#[get("/")]
fn index() -> &'static str {
    "Confirming Rocket is working"
}

#[launch]
fn rocket() -> Rocket<Build> {
    rocket::build()
    .mount("/", routes![index])
}