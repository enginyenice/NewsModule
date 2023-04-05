FROM node:16.16.0 as build

WORKDIR /usr/local/app

COPY ./ /usr/local/app/

RUN npm install --legacy-peer-deps

RUN npm run build

FROM nginx:latest

COPY --from=build /usr/local/app/dist/news-module-frontend /usr/share/nginx/html

EXPOSE 80