@extends('master')

@section('content')
<div class="mx-auto container">
    <div class="flex justify-center items-center h-screen">
        <div style="max-width: 600px;" class="w-full">
            <div class="bg-grey-light px-2 py-2 rounded">
            <div class="text-center font-bold text-2xl tracking-wide py-2">House</div>


            <form method="POST" class="px-2 py-2" action="/offer/{{ $house->id}}">
                        @csrf

                        <div>
                            <label for="address" class="tracking-wide">Address</label>

                            <div class="mb-2">
                                <input id="address" name="address" type="text" class="border rounded h-10 w-full outline-none px-2 border-grey {{ $errors->has('address') ? ' border-red' : 'border-grey' }}" required value="{{ $house->address }}">
                            </div>

                            @if ($errors->has('address'))
                            <span class="text-red-dark" role="alert">
                                <strong>{{ $errors->first('address') }}</strong>
                            </span>
                        @endif
                        </div>

                        <div>
                            <label for="description" class="tracking-wide">Description</label>

                            <div class="mb-2">
                                <textarea id="description" name="description" type="text" class="border rounded h-48 w-full outline-none px-2 border-grey {{ $errors->has('description') ? ' border-red' : 'border-grey' }}" required>{{ $house->description }}</textarea>
                            </div>

                            @if ($errors->has('description'))
                            <span class="text-red-dark" role="alert">
                                <strong>{{ $errors->first('description') }}</strong>
                            </span>
                        @endif
                        </div>

                        <div>
                                <label for="number" class="tracking-wide">Owner phone number</label>

                                <div class="col-md-6">
                                    <input id="number" type="text" class="border rounded h-10 w-full outline-none px-2 {{ $errors->has('number') ? ' border-red' : 'border-grey' }}" name="number" value="{{ $house->owner_phone_nr }}" required>

                                    @if ($errors->has('number'))
                                        <span class="text-red-dark" role="alert">
                                            <strong>{{ $errors->first('number') }}</strong>
                                        </span>
                                    @endif
                                </div>
                            </div>


                        <button type="submit" class="mt-2 rounded px-4 py-2 text-blue-darkest bg-blue-light uppercase font-bold tracking-wide">
                            Update
                        </button>

                    </form>

            </div>
        </div>
    </div>
</div>
@endsection
