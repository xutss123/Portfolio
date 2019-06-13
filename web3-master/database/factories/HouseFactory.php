<?php

use Faker\Generator as Faker;

$factory->define(App\House::class, function (Faker $faker) {
    return [
        'address' => $faker->address(),
        'lease_start' =>$faker->date(),
        'owner_phone_nr' => $faker->e164PhoneNumber(),
        'price' => mt_rand(0, 3500) / 10,
        'is_favorite' => $faker->boolean,
        'description'=> $faker -> text()
    ];
});
