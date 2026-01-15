% Main Image
Main_img = imread('Image.jpg');
gray = rgb2gray(Main_img);
noisy = imnoise(gray, 'salt & pepper', 0.05); % 5% noise
figure(1);
imshow(noisy);
title('Salt & Pepper Noise');

% Median Filter
median_filter = medfilt2(noisy,[3 3]);
figure(2);
imshow(median_filter);
title('Median Filter');
imwrite(median_filter ,"median_filter.png");

% Max Filter
Max_filtered = imdilate(noisy, ones(3,3));
figure(3);
imshow(Max_filtered);
title('Max Filter');
imwrite(Max_filtered,"Max_filter.png");

% Min Filter
min_filtered = imerode(noisy, ones(3,3));
figure(4);
imshow(min_filtered);
title('Min Filter');
imwrite(min_filtered,"Min_filter.png");

% Mean Filter
Mean_Filter = imfilter(noisy, fspecial('average', [3 3]));
figure(5);
imshow(Mean_Filter);
title('Mean Filter');
imwrite(Mean_Filter,"Mean_filter.png");
