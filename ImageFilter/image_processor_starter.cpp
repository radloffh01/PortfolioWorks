#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int main () 
{
  
  const int width = 640;
  const int height = 480;
  unsigned char imagedata[height][width*4];                             /* Each pixel contains 4 colors in 32-bit bitmap image */
  unsigned char header[54];                                             /* Bitmap header is 54 bytes */
  
  //
  /* Notice that the imagedata[][] and header[] are both declared as character arrays.
   * This is because characters are typically 8-bit (1-byte) in size, making them
   * a convenient datatype when we need to read one byte at a time */
  //
  
  string inputFile;
  string outputFile;
  
  cout << "+++++ Image Processor Alpha +++++" << endl << endl;
  cout << "Enter the name of the input image file (.bmp) ";
  getline(cin, inputFile);
  
  //
  /* For various reasons, users often don't include the extension (.bmp) when they specify the filename
   * We may have to manually add the '.bmp' extension to the filename */
  //
  
  if(inputFile.find(".bmp") == std::string::npos)                       /* First check if the user has specified the extension */
  {
    inputFile = inputFile + ".bmp";                                     /* If not, append the '.bmp' extension to the file name */
  }

  ifstream infile;
  infile.open(inputFile, ios::in | ios::binary);                        /* Open file in binary mode so that we can read raw data */
  
  if( infile.fail() )
  {
      cout << "Error: unable to open " << inputFile;
      return -1;
  }
  
  cout << "Enter the output file name (.bmp) ";
  getline(cin, outputFile);
  
  //
  /* Check for the extension and append if necessary */
  //
  
  if(outputFile.find(".bmp") == std::string::npos)                      /* First check if the user has specified the extension */
  {
    outputFile = outputFile + ".bmp";                                   /* If not, append the '.bmp' extension to the file name */
  }
  
  //
  /* Start reading from the input image file */
  //
  
  infile.read((char *)&header[0], sizeof(header));                      /* First, read the header */
  infile.read((char *)&imagedata[0][0], sizeof(imagedata));             /* Next, read the image data */
  infile.close();                                                       /* Close the file, we have what we need */
  
  //
  /* You will need to add your code here to implement the required functionalities */
  //
  int userIn = 0;
  int red, blue, green, alpha;

  while (userIn != 7) {
      cout << "1. blue-pass filter" << endl;
      cout << "2. red-pass filter" << endl;
      cout << "3. green-pass filter" << endl;
      cout << "4. color inversion" << endl;
      cout << "5. color enhancement" << endl;
      cout << "6. Convert to Grayscale" << endl;
      cout << "7. Exit" << endl;

      cout << "Enter your choice:";
      cin >> userIn;

      if (userIn == 7) {
          break;
      }

      if (userIn == 1) { // blue filter
          for (int i = 0; i < height; i++) {
              for (int j = 0; j < width * 4; j++) {
                  switch (j % 4)
                  {
                  case 0:
                      //this is blue color
                      blue = imagedata[i][j];
                      break;

                  case 1:
                      //this is green color
                      green = imagedata[i][j];
                      break;

                  case 2:
                      //this is red color
                      red = imagedata[i][j];
                      break;

                  default:
                      //this is alpha
                      alpha = imagedata[i][j];
                      green = 0;
                      red = 0;

                      imagedata[i][j - 3] = blue;
                      imagedata[i][j - 2] = green;
                      imagedata[i][j - 1] = red;
                      imagedata[i][j] = alpha;
                      break;
                  }
              }
          }
          //
          //

          //
          /* Start writing the modified image data to the file */
          //

          ofstream outfile;
          outfile.open(outputFile, ios::out | ios::binary);

          outfile.write((char*)&header[0], sizeof(header));                    /* First, write the header */
          outfile.write((char*)&imagedata[0][0], sizeof(imagedata));           /* Next, write the image data */
          outfile.close();                                                      /* Finally, close the file */

          cout << "---- Done! ----" << endl;
      }
      else if (userIn == 2) { // red filter
          for (int i = 0; i < height; i++) {
              for (int j = 0; j < width * 4; j++) {
                  switch (j % 4)
                  {
                  case 0:
                      //this is blue color
                      blue = imagedata[i][j];
                      break;

                  case 1:
                      //this is green color
                      green = imagedata[i][j];
                      break;

                  case 2:
                      //this is red color
                      red = imagedata[i][j];
                      break;

                  default:
                      //this is alpha
                      alpha = imagedata[i][j];
                      green = 0;
                      blue = 0;

                      imagedata[i][j - 3] = blue;
                      imagedata[i][j - 2] = green;
                      imagedata[i][j - 1] = red;
                      imagedata[i][j] = alpha;
                      break;
                  }
              }
          }

          ofstream outfile;
          outfile.open(outputFile, ios::out | ios::binary);

          outfile.write((char*)&header[0], sizeof(header));                    /* First, write the header */
          outfile.write((char*)&imagedata[0][0], sizeof(imagedata));           /* Next, write the image data */
          outfile.close();                                                      /* Finally, close the file */

          cout << "---- Done! ----" << endl;

      }
      else if (userIn == 3) { // green filter
          for (int i = 0; i < height; i++) {
              for (int j = 0; j < width * 4; j++) {
                  switch (j % 4)
                  {
                  case 0:
                      //this is blue color
                      blue = imagedata[i][j];
                      break;

                  case 1:
                      //this is green color
                      green = imagedata[i][j];
                      break;

                  case 2:
                      //this is red color
                      red = imagedata[i][j];
                      break;

                  default:
                      //this is alpha
                      alpha = imagedata[i][j];
                      blue = 0;
                      red = 0;

                      imagedata[i][j - 3] = blue;
                      imagedata[i][j - 2] = green;
                      imagedata[i][j - 1] = red;
                      imagedata[i][j] = alpha;
                      break;
                  }
              }
          }

          ofstream outfile;
          outfile.open(outputFile, ios::out | ios::binary);

          outfile.write((char*)&header[0], sizeof(header));                    /* First, write the header */
          outfile.write((char*)&imagedata[0][0], sizeof(imagedata));           /* Next, write the image data */
          outfile.close();                                                      /* Finally, close the file */

          cout << "---- Done! ----" << endl;

      }
      else if (userIn == 4) { // color inversion
          for (int i = 0; i < height; i++) {
              for (int j = 0; j < width * 4; j++) {
                  switch (j % 4)
                  {
                  case 0:
                      //this is blue color
                      blue = imagedata[i][j];
                      break;

                  case 1:
                      //this is green color
                      green = imagedata[i][j];
                      break;

                  case 2:
                      //this is red color
                      red = imagedata[i][j];
                      break;

                  default:
                      //this is alpha
                      alpha = imagedata[i][j];
                      blue = 255 - blue;
                      green = 255 - green;
                      red = 255 - red;

                      imagedata[i][j - 3] = blue;
                      imagedata[i][j - 2] = green;
                      imagedata[i][j - 1] = red;
                      imagedata[i][j] = alpha;
                      break;
                  }
              }
          }
          ofstream outfile;
          outfile.open(outputFile, ios::out | ios::binary);

          outfile.write((char*)&header[0], sizeof(header));                    /* First, write the header */
          outfile.write((char*)&imagedata[0][0], sizeof(imagedata));           /* Next, write the image data */
          outfile.close();                                                      /* Finally, close the file */

          cout << "---- Done! ----" << endl;

      }
      else if (userIn == 5) { // color enhancement
          for (int i = 0; i < height; i++) {
              for (int j = 0; j < width * 4; j++) {
                  switch (j % 4)
                  {
                  case 0:
                      //this is blue color
                      blue = imagedata[i][j];
                      break;

                  case 1:
                      //this is green color
                      green = imagedata[i][j];
                      break;

                  case 2:
                      //this is red color
                      red = imagedata[i][j];
                      break;

                  default:
                      //this is alpha
                      alpha = imagedata[i][j];
                      red = max(0, red-20);
                      blue = max(0, blue-20);

                      imagedata[i][j - 3] = blue;
                      imagedata[i][j - 2] = green;
                      imagedata[i][j - 1] = red;
                      imagedata[i][j] = alpha;
                      break;
                  }
              }
          }
          ofstream outfile;
          outfile.open(outputFile, ios::out | ios::binary);

          outfile.write((char*)&header[0], sizeof(header));                    /* First, write the header */
          outfile.write((char*)&imagedata[0][0], sizeof(imagedata));           /* Next, write the image data */
          outfile.close();                                                      /* Finally, close the file */

          cout << "---- Done! ----" << endl;

      }
      else if (userIn == 6) { // grayscale
          for (int i = 0; i < height; i++) {
              for (int j = 0; j < width * 4; j++) {
                  switch (j % 4)
                  {
                  case 0:
                      //this is blue color
                      blue = imagedata[i][j];
                      break;

                  case 1:
                      //this is green color
                      green = imagedata[i][j];
                      break;

                  case 2:
                      //this is red color
                      red = imagedata[i][j];
                      break;

                  default:
                      //this is alpha
                      alpha = imagedata[i][j];
                      blue = (red + blue + green) / 3;
                      green = (red+blue+green) / 3;
                      red = (red+blue+green) / 3;

                      imagedata[i][j - 3] = blue;
                      imagedata[i][j - 2] = green;
                      imagedata[i][j - 1] = red;
                      imagedata[i][j] = alpha;
                      break;
                  }
              }
          }
          ofstream outfile;
          outfile.open(outputFile, ios::out | ios::binary);

          outfile.write((char*)&header[0], sizeof(header));                    /* First, write the header */
          outfile.write((char*)&imagedata[0][0], sizeof(imagedata));           /* Next, write the image data */
          outfile.close();                                                      /* Finally, close the file */

          cout << "---- Done! ----" << endl;

      }
  }
  
  return 0;
}
