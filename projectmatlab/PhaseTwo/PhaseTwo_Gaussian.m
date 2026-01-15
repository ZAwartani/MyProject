% Main Image
Main_Image = imread('image.jpg');
gray = rgb2gray(Main_Image);
noisy = imnoise(gray, 'gaussian', 0, 0.01); % 0 = mean, 0.01 = variance
imshow(noisy);
title('Image with Gaussian Noise');

% Median Filter
median_filter = medfilt2(gray,[3 3]);
figure(2);
imshow(median_filter);
title('Median Filter');
imwrite(median_filter ,"median_filter_Gaussian.png");

% Max Filter
Max_filtered = imdilate(noisy, ones(3,3));
figure(3);
imshow(Max_filtered);
title('Max Filter');
imwrite(Max_filtered,"max_filter_Gaussian.png");
 
% Min Filter
min_filtered = imerode(noisy, ones(3,3));
figure(4);
imshow(min_filtered);
title('Min Filter');
imwrite(min_filtered,"min_filter_Gaussian.png");

% Mean Filter
Mean_Filter = imfilter(noisy, fspecial('average', [3 3]));
figure(5);
imshow(Mean_Filter);
title('Mean Filter');
imwrite(Mean_Filter,"Mean_filter_Gaussian.png");