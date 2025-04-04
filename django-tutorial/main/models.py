from django.db import models

class Book(models.Model):
    def __str__(self):
        return self.title

    title = models.CharField(
        blank=False,
        unique=True,
        max_length=36,
    )
    description = models.TextField(
        max_length=255,
        blank=True,
    )
    price = models.DecimalField(
        default=0,
        max_digits=3,
        decimal_places=2,
    )
    published = models.DateField(
        null=True
    )
    is_published = models.BooleanField(
        default=False,
    )
    cover = models.ImageField(
        upload_to='covers/',
        blank=True
    )