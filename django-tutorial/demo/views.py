from django.shortcuts import render
from django.http import HttpResponse
from django.views import View
from .models import Book
from django.shortcuts import render
from rest_framework import viewsets

from .serializers import BookSerializer


def first(request) -> HttpResponse:
    books = Book.objects.all()
    return render(request, 'first_template.html', {'books': books})

class BookViewSet(viewsets.ModelViewSet):
    serializer_class = BookSerializer
    queryset = Book.objects.all()