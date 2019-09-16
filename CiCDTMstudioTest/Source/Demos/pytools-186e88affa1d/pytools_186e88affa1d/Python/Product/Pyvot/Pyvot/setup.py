# Copyright (c) Microsoft Corporation. 
#
# This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
# copy of the license can be found in the LICENSE.txt file at the root of this distribution. If 
# you cannot locate the Apache License, Version 2.0, please send an email to 
# vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
# by the terms of the Apache License, Version 2.0.
#
# You must not remove this notice, or any other, from this software.

#
# This file must work in both Python 2 and 3 as-is (without applying 2to3) 
#

import sys

# If setuptools available, we normally want to install dependencies. The --no-downloads flag
# allows the PTVS installer to prevent this, to avoid network-related failure cases
allow_downloads = True

no_downloads_flag = '--no-downloads'
if no_downloads_flag in sys.argv:
    sys.argv.remove(no_downloads_flag)
    allow_downloads = False

try:
    from setuptools import setup, Distribution
    use_setuptools = True
except ImportError:
    from distutils.core import setup, Distribution
    use_setuptools = False

running_python3 = sys.version_info.major > 2

# Sets __version__ as a global without importing xl's __init__. We might not have pywin32 yet.
with open(r'.\xl\version.py') as version_file:
    exec(version_file.read(), globals())

class PyvotDistribution(Distribution):
    def find_config_files(self):
        configs = Distribution.find_config_files(self)
        configs.append("setup.py3.cfg" if running_python3 else "setup.py2.cfg")
        return configs

long_description = \
    """Pyvot connects familiar data-exploration and visualization tools in Excel with the powerful data analysis 
    and transformation capabilities of Python, with an emphasis on tabular data. It provides a minimal and Pythonic 
    interface to Excel, smoothing over the pain points in using the existing Excel object model as exposed via COM."""

setup_options = dict(
      name="Pyvot",
      version=__version__,
      author="Microsoft Corporation",
      author_email="vspython@microsoft.com",
      license="Apache License 2.0",
      description="Pythonic interface for data exploration in Excel",
      long_description=long_description,
      download_url="http://pypi.python.org/pypi/Pyvot",
      url="http://pytools.codeplex.com/wikipage?title=Pyvot",
      classifiers=[
        'Development Status :: 4 - Beta',
        'Environment :: Win32 (MS Windows)',
        'Operating System :: Microsoft :: Windows',
        'Programming Language :: Python',
        'Programming Language :: Python :: 2',
        'Programming Language :: Python :: 3',
        'Topic :: Office/Business :: Financial :: Spreadsheet',
        'License :: OSI Approved :: Apache Software License'],
      packages=['xl', 'xl._impl'],
      distclass=PyvotDistribution
    )

if running_python3:
    use_2to3 = True
    from distutils.command.build_py import build_py_2to3
    setup_options.update(dict(
        cmdclass={'build_py': build_py_2to3}
    ))

if use_setuptools:
    setup_options.update(dict(
        zip_safe=True
    ))
if use_setuptools and allow_downloads:
    setup_options.update(dict(
        setup_requires=["Sphinx"],
    ))

setup(**setup_options)
