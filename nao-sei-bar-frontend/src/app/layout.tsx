import type { Metadata } from "next";
import localFont from "next/font/local";
import "./globals.css";

const geistSans = localFont({
  src: "./fonts/GeistVF.woff",
  variable: "--font-geist-sans",
  weight: "100 900",
});
const geistMono = localFont({
  src: "./fonts/GeistMonoVF.woff",
  variable: "--font-geist-mono",
  weight: "100 900",
});

const oswald = localFont({
  src: './fonts/Oswald-VariableFont_wght.ttf',
  variable: '--font-oswald-semibold',
  weight: "100 900"
})

export const metadata: Metadata = {
  title: "Não Sei Bar",
  description: "Projeto para a disciplina de MPS",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="pt-BR">
      <body
        className={`${oswald.variable} antialiased`}
      >
        {children}
      </body>
    </html>
  );
}
