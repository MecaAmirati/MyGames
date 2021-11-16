from random import randint
status = 'Vencedor'
c = 0
while status == 'Vencedor':
    n = int(input('Escolha um valor: '))
    parImpar = str(input('Você quer Par ou Ímpar [P/I]: ')).strip().upper()[0]
    pc = randint(0, 100)
    total = pc + n
    if parImpar in 'Pp':
        if total % 2 == 0:
            print(f'Você escolheu {n} e eu escolhi {pc}\n'
                  f'A soma desses dois valores ({total}) é Par.\n'
                  'Você venceu!\n'
                  'Vamos continuar!\n')
            c += 1
            status = 'Vencedor'
        else:
            print(f'Você escolheu {n} e eu escolhi {pc}\n'
                  f'A soma desses dois valores ({total}) é Ímpar.\n'
                  f'Você Perdeu... mas ganhou {c} vez(es)\n')
            status = 'Perdedor'
            break
    if parImpar in 'Ii':
        if total % 2 == 1:
            print(f'Você escolheu {n} e eu escolhi {pc}\n'
                  f'A soma desses dois valores ({total}) é Ímpar.\n'
                  'Você venceu!\n'
                  'Vamos continuar!\n')
            c += 1
            status = 'Vencedor'
        else:
            print(f'Você escolheu {n} e eu escolhi {pc}\n'
                  f'A soma desses dois valores ({total}) é Par.\n'
                  f'Você Perdeu... mas ganhou {c} vez(es)\n')
            status = 'Perdedor'
            break
print('Foi um bom jogo!')
