﻿using BusinessObject.Model;
using DataAccess.Repository;
using System.Windows;

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminMemberCreate.xaml
    /// </summary>
    public partial class AdminMemberCreate : Window
    {
        private readonly IMemberRepository memberRepository;
        private readonly AdminMember adminMember;
        private Member? member;

        public AdminMemberCreate(AdminMember _adminMember, Member? _member, IMemberRepository _memberRepository)
        {
            InitializeComponent();
            this.memberRepository = _memberRepository;
            this.adminMember = _adminMember;
            this.member = _member;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (member != null)
            {
                txtBoxEmail.Text = member.Email ?? string.Empty;
                txtBoxCompanyName.Text = member.CompanyName ?? string.Empty;
                txtBoxCity.Text = member.City ?? string.Empty;
                txtBoxCountry.Text = member.Country ?? string.Empty;
                txtBoxPassword.Password = member.Password ?? string.Empty;
                txtBoxId.Text = member.MemberId.ToString();
                txtBoxId.Visibility = Visibility.Visible;
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
                this.Height = 550;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtBoxEmail.Text;
            string companyName = txtBoxCompanyName.Text;
            string city = txtBoxCity.Text;
            string country = txtBoxCountry.Text;
            string password = txtBoxPassword.Password;

            Member p = member ?? new Member();

            p.Email = email;
            p.CompanyName = companyName;
            p.City = city;
            p.Country = country;
            p.Password = password;

            if (member != null)
            {
                memberRepository.Update(p);
            }
            else
            {
                memberRepository.Add(p);
            }
            this.Close();
            adminMember.RefreshListView();
        }
    }
}
