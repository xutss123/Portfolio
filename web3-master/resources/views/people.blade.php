@extends('master')

@section('content')
<a class="mx-2 px-2 no-underline rounded py-2 text-yellow-darkest bg-yellow-light uppercase font-bold tracking-wide" href="/people/export">Export</a>
<br />
<br />
<div class="px-2 py-2">
        <table class="border border-black rounded w-full">
                <thead>
                    <tr class="border-b border-black bg-grey-dark ">
                        <th class="uppercase tracking-wide py-1">Name</th>
                        <th class="uppercase tracking-wide py-1">Email</th>
                    </tr>
                </thead>
                <tbody>
                    @forEach($data as $user)
                        <tr class="border-b border-black">
                            <td class="py-1 px-2">{{ $user['name'] }}</td>
                            <td class="py-1 px-2">{{ $user['email'] }}</td>
                        </tr>
                    @endForEach
                </tbody>
            </table>
</div>
@endsection
