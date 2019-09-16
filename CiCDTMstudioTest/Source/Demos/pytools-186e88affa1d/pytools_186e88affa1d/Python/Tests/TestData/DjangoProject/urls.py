from django.conf.urls import patterns, include, url

# Uncomment the next two lines to enable the admin:
from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'DjangoApplication1.views.home', name='home'),
    # url(r'^DjangoApplication1/', include('DjangoApplication1.fob.urls')),

    # Uncomment the admin/doc line below to enable admin documentation:
    # url(r'^admin/doc/', include('django.contrib.admindocs.urls')),

    # Uncomment the next line to enable the admin:
    url(r'^admin/', include(admin.site.urls)),
    url(r'^Oar/$', 'Oar.views.index'),
    url(r'^/$', 'oar.views.main'),
    url(r'^loop_nobom/$', 'Oar.views.loop_nobom'),
    url(r'^loop/$', 'Oar.views.loop'),
    url(r'^loop2/$', 'Oar.views.loop2'),
)
