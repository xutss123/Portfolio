<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class House extends Model
{
    protected $table = 'house';

    protected $fillable = [
        'address', 'lease_start', 'owner_phone_nr', 'description', 'is_favorite', 'price', 'user_id'
    ];

}
