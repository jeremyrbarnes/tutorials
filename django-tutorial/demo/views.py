from django.shortcuts import render
from django.http import HttpResponse
from django.views import View
from .models import Book

class Another(View):

    book = Book.objects.get(id=2)
    output = ''
    #for book in books:
    output += f"We have {book.title} with ID {book.id}<br />"

    def get(self, request: object) -> HttpResponse:
        return HttpResponse(self.output)

def first(request) -> HttpResponse:
    return HttpResponse("First message from views")