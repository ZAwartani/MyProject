I1 = imread('ChatGPT Image Nov 30, 2025, 06_20_05 PM.png');
figure(1);
imshow(I1);
title("Original");
[row,col] = size(I1);
old_min = min(I1(:));
old_max = max(I1(:));
new_min = 0;
new_max = 255;
for x=1:row
    for y=1:col
        I2(x,y) = ((I1(x,y) - old_min) / (old_max - old_min)) * (new_max - new_min) + new_min;
    end
end

figure(2);
imshow(I2);
title("contrast streching");
imwrite(I2,"After edit.png");

% Contrast Streching

% r = 127;
% for x = 1:row
%     for y = 1:col
%         if I1(x,y) >= r
%             I3(x,y) = 1;
%         else
%             I3(x,y) = 0;
%         end
%     end
% end
% figure(3);
% imshow(I3);
% title("Thresholding");
% imwrite(I3 , "Thresholding.png");
% 
% % Threshoulding
% 
% for x=1:row
%     for y=1:col
%         I4(x,y) = 255-I1(x,y);
%     end
% end
% 
% figure(4);
% imshow(I4);
% title("negative");
% imwrite(I4,"Negative.png");
% 
% % Negative
% 
% I1 = double(I1);
% c = 255 / log(1 + max(I1(:)));
% I5 = c * log(1 + I1);
% I5 = uint8(I5);
% figure(5);
% imshow(I5);
% title("Log Transformation");
% imwrite(I5, "Log.png");
% 
% % Log       
% 
% I1 = double(I1);           
% gamma = 0.65;
% I6 = I1 .^ gamma;           
% I6(I6 > 255) = 255;
% I6 = uint8(I6);            
% figure(6);
% imshow(I6);
% title("Gamma");
% imwrite(I6,"Gamma.png");
% 
% % Gamma
% 
% for x = 1:row
%     for y = 1:col
%         if I1(x,y) <= 100
%             I7(x,y) = I1(x,y) * 1.5;
%         elseif I1(x,y) > 100 & I1(x,y) <= 200
%             I7(x,y) = I1(x,y) * 1.2;
%         else
%             I7(x,y) = 255;
%         end
%         
%         if I7(x,y) > 255
%             I7(x,y) = 255;
%         end
%     end
% end
% figure(7);
% imshow(I7);
% title("Piecewise");
% imwrite(I7,"Piecewise.png");