<?php

use Illuminate\Database\Seeder;
use App\House;

class HouseTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */

    public function run()
    {
        factory(\App\House::class, 100)->create();
    }
}
