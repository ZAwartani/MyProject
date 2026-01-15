clc; clear; close all;

%% 1) Read the clean image
img = imread('text.png');
if size(img,3) == 3
    img = rgb2gray(img);
end

%% 2) Convert to binary and invert
bw = imbinarize(img);
bw = ~bw;

%% 3) Structuring element
se = strel('square',4);  

%% 4) Apply Erosion
eroded = imerode(bw,se);
imwrite(eroded,'erosion.png');

figure;
imshow(eroded);
title('Erosion');

%% 5) Apply Dilation
dilated = imdilate(bw,se);
imwrite(dilated,'dilation.png');

figure;
imshow(dilated);
title('Dilation');

%% 6) Apply Opening
opened = imopen(bw,se);
imwrite(opened,'opening.png');

figure;
imshow(opened);
title('Opening');

%% 7) Apply Closing
closed = imclose(bw,se);
imwrite(closed,'closing.png');

figure;
imshow(closed);
title('Closing');

%% 8) Original Image (optional to show alone)
figure;
imshow(bw);
title('Original Binary');
