codeFile = 'forMe.m';

% Publish to PDF
options = struct('format','pdf','showCode',true,'outputDir',pwd);
publish(codeFile, options);

disp('PDF created successfully in the current folder!');